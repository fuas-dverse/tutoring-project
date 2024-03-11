import React from "react"
import {Navbar, Container, Nav} from "react-bootstrap";
import {useEffect, useState} from "react";
import logo from '../assets/mundusWhite.png';
import {BrowserRouter, NavLink} from "react-router-dom";
import {
    BrowserRouter as Router,
    Route,
    Link,
    Routes
} from "react-router-dom";


import HomePage from "../pages/HomePage";
import LoginPage from "../pages/LoginPage";
import SignUpPage from "../pages/SignUpPage";
import Logout from "./Logout";

export const NavigationBar = () => {
    const [activeLink, setActiveLink] = useState('home');
    const [scrolled, setScrolled] = useState(false);

    useEffect (() => {
        const onScroll = () => {
            if (window.scrollY > 50) {
                setScrolled(true)
            } else {
                setScrolled(false)
            }
        }
        window.addEventListener("scroll", onScroll)

        return () => window.removeEventListener("scroll", onScroll);
    } , [])

    const onUpdateActivateLink = (value) => {
        setActiveLink(value)
    }


    return (
        <BrowserRouter>
            <Navbar expand="lg" className={scrolled ? "scrolled": ""}>
                <Container>
                    <Navbar.Brand href="/home">
                        <img src={logo} alt="Logo" />
                    </Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav">
                        <span className="navbar-toggler-icon"></span>
                    </Navbar.Toggle>
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <NavLink as={Link} to={"/home"} className={activeLink === 'home' ? 'active navbar-link': 'navbar-link'} onClick={() => onUpdateActivateLink('home')}>Home</NavLink>
                        </Nav>
                        <span className="navbar-text">
                    <button data-cy="logout" className="vvd" onClick={() => window.location.href="/logout"}><span>Logout</span>
                   </button>
                    </span>
                    </Navbar.Collapse>
                </Container>
            </Navbar>

            <Routes>
                <Route path={"/home"} element={<HomePage />} />
                <Route path={"/"} element={<HomePage />} />
                <Route path={"/login"} element={<LoginPage />} />
                <Route path={"/signup"} element={<SignUpPage />} />
                <Route path={"/logout"} element={<Logout />} />
            </Routes>
        </BrowserRouter>
    )
}

