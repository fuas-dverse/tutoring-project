import React, {Component, useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import {useNavigate} from "react-router-dom";
import AuthenticationService from "../services/AuthenticationService";


export default class Login extends Component {
    render(){
        // eslint-disable-next-line react-hooks/rules-of-hooks
        let navigate=useNavigate();
        // eslint-disable-next-line react-hooks/rules-of-hooks
        const[message, setMessage] = useState("");

        // eslint-disable-next-line react-hooks/rules-of-hooks
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
                    const roles = response.roles;
                    //for debug
                    console.log("Login: " + "AccessToken: " + accessToken);
                    console.log("Roles: " + roles);
                    navigate("/users");

                })
                .catch(message => setMessage("Invalid credentials"));
        };

        return (
            <section className="signup">
                <section className="logincard">
                    <form onSubmit={(e)=> onSubmit(e)}>
                        <h3>Sign In</h3>
                        <div className="mb-3" >
                            <label>Email address</label>
                            <input
                                data-cy="pls"
                                type="email"
                                className="form-control"
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
                                data-cy="password"
                                type="password"
                                className="form-control"
                                placeholder="Enter password"
                                id="password"
                                name="password"
                                value={password}
                                onChange={(e)=>onInputChange(e)}
                            />
                        </div>
                        <div className="mb-3">
                            <div className="custom-control custom-checkbox">
                                <input
                                    type="checkbox"
                                    className="custom-control-input"
                                    id="customCheck1"
                                />
                                <label className="custom-control-label" htmlFor="customCheck1">
                                    Remember me
                                </label>
                            </div>
                        </div>
                        <div className="d-grid" >
                            <button id="submitBtn" data-cy="loginSubmit" type="submit"  className="btn btn-primary">
                                Submit
                            </button>
                        </div>
                        <p className="forgot-password text-right">
                            Forgot <a href="#">password?</a>
                        </p>
                    </form>
                </section>
            </section>
        )
    }
}