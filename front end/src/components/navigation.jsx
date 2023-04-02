import React from "react";
import 'bootstrap/dist/css/bootstrap.css';
import { NavLink } from "react-router-dom";
import logoimage from './widelogo.png'

function Navigation() {
    return (
        <nav className="navbar navbar-expand-sm fixed-top navbar-light border-bottom border-3 border-dark">
            <div className="container-fluid">
                <NavLink className="navbar-brand" to="/">
                    <img src={logoimage} className="App-logo" alt="logo"/>
                </NavLink>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul className="navbar-nav navbar-right navbar-right ms-auto">
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/">
                                <h5>Home</h5>
                            </NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/tool">
                                <h5>Use tool</h5>
                            </NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/login">
                                <h5>Login</h5>
                            </NavLink>
                        </li>

                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Navigation;