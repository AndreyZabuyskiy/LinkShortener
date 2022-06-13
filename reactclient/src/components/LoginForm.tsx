import React, { SyntheticEvent, useState } from "react";
import { useDispatch } from "react-redux";
import { fetchLogin } from "../api/loginApi";

const LoginForm = () => {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const dispatch = useDispatch();

  const changeInputLogin = (e: React.ChangeEvent<HTMLInputElement>) => {
    setLogin(e.target.value);
  }
  
  const changeInputPassword = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  }

  const submit = (e: SyntheticEvent) => {
    e.preventDefault();

    dispatch(fetchLogin({ login, password }));
  }

  return (
    <form onSubmit={submit}>
      <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
      <input type="text" className="form-control" placeholder="login"
      value={login} onChange={changeInputLogin} />
      <input type="password" className="form-control" placeholder="Password"
      value={password} onChange={changeInputPassword} />
      <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>
    </form>
  );
}

export default LoginForm;