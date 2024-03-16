import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from "react-router-dom";
import AuthenticationService from "../services/AuthenticationService";

const Login = () => {
    const navigate = useNavigate();
    const [message, setMessage] = useState("");
    const [user, setUser] = useState({
        email: "",
        password: ""
    });

    const { email, password } = user;

    const onInputChange = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value });
    };

    const onSubmit = (e) => {
        e.preventDefault();
        console.log(user);
        AuthenticationService.login(user)
            .then(response => {
                const accessToken = response.accessToken;
                const roles = response.roles;
                //for debug
                console.log("Login: " + "AccessToken: " + accessToken);
                console.log("Roles: " + roles);
                navigate("/studyMaterials");
            })
            .catch(error => setMessage("Invalid credentials"));
    };

    return (
        <section className="signup">
            <section className="logincard">
                <form onSubmit={onSubmit}>
                    <h3>Sign In</h3>
                    <div className="mb-3" >
                        <label>Email address</label>
                        <input
                            type="email"
                            className="form-control"
                            placeholder="Enter email"
                            name="email"
                            value={email}
                            onChange={onInputChange}
                        />
                    </div>
                    <div className="mb-3">
                        <label>Password</label>
                        <input
                            type="password"
                            className="form-control"
                            placeholder="Enter password"
                            name="password"
                            value={password}
                            onChange={onInputChange}
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
                    <div className="d-grid">
                        <button type="submit" className="btn btn-primary">Submit</button>
                    </div>
                    <p className="forgot-password text-right">
                        Forgot <a href="#">password?</a>
                    </p>
                    {message && <div className="alert alert-danger">{message}</div>}
                </form>
            </section>
        </section>
    )
}

export default Login;
