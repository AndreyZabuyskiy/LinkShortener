import { SyntheticEvent, useState } from "react";
import { useDispatch } from "react-redux";
import { fetchRegister } from "../api/register";

const RegisterForm = () => {
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

    dispatch(fetchRegister({ login, password }));
  }

  return (
    <form onSubmit={submit}>
      <h1 className="h3 mb-3 fw-normal">Please register</h1>

      <input type="text" className="form-control" placeholder="login"
        onChange={changeInputLogin} value={login} />

      <input type="password" className="form-control" placeholder="Password"
        onChange={changeInputPassword} value={password} />

      <button className="w-100 btn btn-lg btn-primary" type="submit">Submit</button>
    </form>
  );
}

export default RegisterForm;