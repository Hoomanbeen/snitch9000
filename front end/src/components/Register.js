import React, { useState } from 'react';
import axios from 'axios';

const Register = () => {
    const [email, setEmail] = useState('');
    const [pwd, setPwd] = useState('');
    const [confirmPwd, setConfirmPwd] = useState('');
    const [success, setSuccess] = useState(false);

    const handleSubmit = event => {
        event.preventDefault();

        const user = {
            "email": email,
            "password": pwd
        };

        axios.post('https://localhost:8080/User/register', user)
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
                <section className="user-form">
                    <h1>You are registered!</h1>
                    <br />
                    <p>
                        <a href="/tool">Go to Tool</a>
                    </p>
                </section>
            ) : (
                <div className="user-form">
                    <h1>Register</h1>
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

                        <div>
                            <label htmlFor="confirmPwd">Confirm Password:</label>
                            <br />
                            <input
                                type="password"
                                id="confirmPwd"
                                onChange={(e) => setConfirmPwd(e.target.value)}
                                value={confirmPwd}
                                required
                            />
                        </div>
                        {confirmPwd.length === 0 && <p></p>}
                        {confirmPwd.length !== 0 && confirmPwd !== pwd && <p>Must match the first password input field.</p>}
                        {confirmPwd.length !== 0 && confirmPwd === pwd && <p></p>}
                        <br />
                        <button type="submit">Register</button>
                    </form>
                    <br />
                    <p>
                        Already have an Account?<br />
                        <span>
                            <a href="/login">Login here</a>
                        </span>
                    </p>
                </div>
            )}
        </>
    )
}
export default Register;
