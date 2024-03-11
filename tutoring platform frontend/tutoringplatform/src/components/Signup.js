import React, {Component, useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from "axios";
import {Navigate, useNavigate} from "react-router-dom";
import * as Yup from "yup";
import { yupResolver } from '@hookform/resolvers/yup'
import { useForm } from 'react-hook-form'

const url = 'http://localhost:8080/users';



const SignUp = () => {


    const yupValidation = Yup.object().shape({
        email: Yup.string().required('Email is mandatory').email(),
        password: Yup.string()
            .required('Please create your password')
            .min(4, 'Add minimum 4 characters'),
        name: Yup.string().required('Name is mandatory'),
        surname: Yup.string().required('Surname is mandatory'),
    })

    const formOptions = { resolver: yupResolver(yupValidation) }
    const {formState } = useForm(formOptions);
    const { errors } = formState

    const navigate = useNavigate();
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [surname, setSurname] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState('organizer');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const resp = await axios.post(url, {name: name, email: email, surname:surname, role: role, password: password});
            console.log(resp.data);
            navigate("/login");
        } catch (error) {
            console.log(error.response);
        }
    };

    return (
        <section className="signup">
            <section className="logincard">
                <form>
                    <h3>Sign Up</h3>
                    <div className="mb-3">
                        <label>First name</label>
                        <input
                            type="text"
                            className={`form-control ${errors.name ? 'is-invalid' : ''}`}
                            placeholder="First name"
                            id='name'
                            required value={name}
                            onChange={(e) => setName(e.target.value)}
                        />
                        <div className="invalid-feedback">{errors.name?.message}</div>
                    </div>

                    <div className="mb-3">
                        <label>Last name</label>
                        <input type="text"
                               className={`form-control ${errors.surname ? 'is-invalid' : ''}`}
                               placeholder="Last name"
                               id='surname'
                               required value={surname}
                               onChange={(e) => setSurname(e.target.value)}/>
                    </div>
                    <div className="invalid-feedback">{errors.surname?.message}</div>
                    <div className="mb-3">
                        <label>Email address</label>
                        <input
                            type="email"
                            className={`form-control ${errors.email ? 'is-invalid' : ''}`}
                            placeholder="Enter email"
                            id='email'
                            required value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                    </div>
                    <div className="invalid-feedback">{errors.email?.message}</div>
                    <div className="mb-3">
                        <label>Password</label>
                        <input
                            type="password"
                            className={`form-control ${errors.password ? 'is-invalid' : ''}`}
                            placeholder="Enter password"
                            id='password'
                            required value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <div className="invalid-feedback">{errors.password?.message}</div>
                    <div className="mb-3">
                        <label>Account</label>
                        <select type="account" className="form-control"
                                placeholder="Enter type of account"
                                id='role'
                                required value={role}
                                onChange={(e) => setRole(e.target.value)}>
                            <option value="tutor">TUTOR</option>
                            <option value="student">STUDENT</option>
                        </select>
                    </div>
                    <div className="d-grid">
                        <button type="submit" className="btn btn-primary" onClick={handleSubmit}>
                            Sign Up
                        </button>
                    </div>
                    <p className="forgot-password text-right">
                        Already registered <a href="/login">sign in?</a>
                    </p>
                </form>
            </section>
        </section>
    )
}

export default SignUp;