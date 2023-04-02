import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import { NavLink } from 'react-router-dom';
import how from './howto.png';
import logoimage from './logonotext.png'

const Home = () => {
  return (
    <div id="home">
        <div id="home" className="container-fluid home" style={{ padding: "150px 40px" }}>
        <br></br>
        <h1 style={{fontWeight: "bold"}}>Welcome to Snitch 9000</h1>
        <p style={{padding:"00px 8px"}}>We are the solution to all your online cheating problems. </p>
        <h3 style={{padding:"00px 8px"}}>Its easy!</h3>
        <img src={how} className="image-id" alt="how to use"/>
        <br></br>
        <br></br>
        <NavLink className="nav-link" to="/tool">
            <center>
                <button type="button" className="btn btn-primary btn-lg"> <h3 style={{fontWeight: "bold"}}>Use Tool</h3></button>
            </center>
        </NavLink>
        <br></br>
        <br></br>
            <br></br>

        <div id="about" className="container-fluid about" style={{padding:"100px 40px"}}>
            <h1>About</h1>
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
        </div>
    </div>
  );
};
  
export default Home;