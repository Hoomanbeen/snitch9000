import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import logo from './Snitch.svg';
import how from './howto.png';
import logoimage from './logonotext.png'
import { NavLink as Link } from "react-router-dom";

class Navbar extends Component {
    render() { 
        return (
        <React.Fragment>
            <body data-bs-spy="scroll" data-bs-target=".navbar" data-bs-offset="50">
                <nav className="navbar navbar-expand-sm fixed-top navbar-light border-bottom border-3 border-dark">
                    <div className="container-fluid">
                    <a className="navbar-brand" href="#home"><h2 style={{fontWeight: "bold"}}>SNITCH-9000</h2></a>
                    <a className="navbar-brand" href="#home"><img src={logo} className="App-logo" alt="logo"/></a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="collapsibleNavbar">
                        <ul className="navbar-nav navbar-right navbar-right ms-auto">
                            <li className="nav-item">
                                <a className="nav-link" href="#home"><h5>Home</h5></a>
                            </li>
                            <li className="nav-item">
                                        <a className="nav-link" href="#tool"><h5>Use tool</h5></a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#about"><h5>About us</h5></a>
                            </li>  
                        </ul>
                    </div>
                    </div>
                </nav>
                    <div id="home" className="container-fluid home" style={{ padding: "150px 40px" }}>
                        <br></br>
                        <h1 style={{fontWeight: "bold"}}>Welcome to Snitch 9000</h1>
                        <p style={{padding:"00px 8px"}}>We are the solution to all your online cheating problems. </p>
                        <h3 style={{padding:"00px 8px"}}>Its easy!</h3>
                        <img src={how} className="image-id" alt="how to use"/>
                    </div>

                    <div id="tool" className="container-fluid tool" style={{padding:"100px 40px"}}>
                        <h1>Use Snitch 9000</h1>
                        <div className="container-fluid">
                            <div className="row">
                                <div className="col-sm-6">
                                    <p>
                                    <span className="badge bg-danger">4</span>
                                    &nbsp;Instances found!
                                    </p>
                                    <ul className="list-group" style={{padding:"0px 0px", overflow: "scroll", height:"150px", width:"100%"}}>
                                        <li className="list-group-item">First item</li>
                                        <li className="list-group-item">Second item</li>
                                        <li className="list-group-item">Third item</li>
                                        <li className="list-group-item">Fourth item</li>
                                    </ul> 
                                </div>
                                <div className="col-sm-6">
                                <form>
                                    <div className="mb-3 mt-3">
                                    <label for="input">Enter the exam question or assignment here:</label>
                                    <textarea className="form-control" rows="5" id="input" name="text"></textarea>
                                    </div>
                                    <button type="submit" className="btn btn-primary">Submit question</button>
                                </form>
                                </div>
                            </div>
                        </div> 
                    </div>

                    <div id="about" className="container-fluid about" style={{padding:"100px 40px"}}>
                        <h1>About</h1>
                        <br></br>
                        <div className="row">
                            <div className="col-sm-9">
                                <h3>Developed by</h3>
                                <br></br>
                                <table>
                                    <tr>
                                        <td><h5>Benjamin Wilson</h5></td>
                                        <td><h5>Team lead and Backend Developer </h5></td>
                                    </tr>
                                    <tr>
                                        <td><h5>Nathan Laing</h5></td>
                                        <td><h5>Backend Developer</h5></td>
                                    </tr>
                                    <tr>
                                        <td><h5>Tony Lin</h5></td>
                                        <td><h5>Integration</h5></td>
                                    </tr>
                                    <tr>
                                        <td><h5>Saam Mardani</h5></td>
                                        <td><h5>Frontend Developer</h5></td>
                                    </tr>
                                    <tr>
                                        <td><h5>Hareen Sendanayake &nbsp; &nbsp;</h5></td>
                                        <td><h5>Frontend Developer</h5></td>
                                    </tr>
                                </table>
                            </div>
                            <div className="col-sm-3">
                                <img src={logoimage} className="img" alt="logo without text"></img>
                            </div>
                        </div>
                    </div>
            </body>
        </React.Fragment>);
    }
}
 
export default Navbar ;