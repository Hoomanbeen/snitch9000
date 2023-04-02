import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Login = () => {

    const [email, setEmail] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);

    const handleSubmit = event => {
        event.preventDefault();

        const user = {
            "email": email,
            "password": pwd
        };

        axios.post('https://localhost:8080/User/login', user)
            .then(res => {
                console.log(res);
                setSuccess(true);
            }).catch(err => {
                console.log(err.message);
            })
    }

    return (
        <>
            {success ? (
                <section>
                    <h1>You are logged in!</h1>
                    <br />
                    <p>
                        <a href="/tool">Go to Tool</a>
                    </p>
                </section>
            ) : (
                <div className="user-form">
                    <h1>Sign in</h1>
                    <br />
                    <form onSubmit={handleSubmit}>
                        <div>
                            <label htmlFor="email">Email:</label>
                            <br />
                            <input
                                type="text"
                                id="email"
                                autoComplete="off"
                                onChange={(e) => setEmail(e.target.value)}
                                value={email}
                                required
                            />
                        </div>

                        <div>
                            <label htmlFor="password">Password:</label>
                            <br />
                            <input
                                type="password"
                                id="password"
                                onChange={(e) => setPwd(e.target.value)}
                                value={pwd}
                                required
                            />
                        </div>
                        <br />
                        <button type="submit">Sign In</button>
                    </form>
                    <br />
                    <p>
                        Need an account?<br />
                        <span>
                            <a href="/register">Create an account</a>
                        </span>
                    </p>
                </div>
            )}
        </>
    )
}

export default Login;
