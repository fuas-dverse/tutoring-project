import React, {Component, useState} from "react";
import '../App.css'
import AuthenticationService from "../services/AuthenticationService";
import {useNavigate} from "react-router-dom";



function LoginPage() {


    let navigate=useNavigate();
    const[message, setMessage] = useState("");


    const [user, setUser] = useState(
        {
            email: "",
            password: ""
        }
    );
    const {email, password} = user;

    const onInputChange = (e)=>{
        setUser({...user,[e.target.name]:e.target.value})
    };

    const onSubmit = (e) =>{

        e.preventDefault();
        console.log(user);
        AuthenticationService.login(user)
            .then(response =>{
                const accessToken = response.accessToken;
                const roles = response.role;
                const userId = AuthenticationService.getId();
                //for debug
                console.log("Login: " + "AccessToken: " + accessToken);
                console.log("Roles: " + roles);
                console.log("Id " + userId);

                if (response.role ==="client"){
                    navigate("/events");
                } else if(response.role === "organizer")
                {
                    navigate(`/myEvents/${userId}`);
                }


            })
            .catch(message => setMessage("Ivalid credentials"));

    };
    return (
        <div>
            <div className="top-panel">
                <h3>Login Page</h3>
            </div>
            <div className="page-layout">
                <div className="page-container">
                    {/* <Login /> */}
                    <section className="signup">
                        <section className="logincard">
                            <form onSubmit={(e)=> onSubmit(e)}>
                                <h3>Sign In</h3>
                                <div className="mb-3">
                                    <label>Email address</label>
                                    <input
                                        type="email"
                                        className='form-control'
                                        placeholder="Enter email"
                                        id="email"
                                        name="email"
                                        value={email}
                                        onChange={(e)=>onInputChange(e)}
                                    />

                                </div>

                                <div className="mb-3">
                                    <label>Password</label>
                                    <input
                                        type="password"
                                        className='form-control'
                                        placeholder="Enter password"
                                        id="password"
                                        name="password"
                                        value={password}
                                        onChange={(e)=>onInputChange(e)}
                                    />
                                </div>
                                <div className="d-grid">
                                    <button type="submit" className="btn btn-primary">
                                        Submit
                                    </button>
                                </div>
                            </form>
                            <div>{message}</div>
                        </section>
                    </section>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;