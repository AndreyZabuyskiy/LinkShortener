import { useState } from "react";

const RegisterForm = () => {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');

  

  return (
    <form>
      <h1 className="h3 mb-3 fw-normal">Please register</h1>
      <input type="text" className="form-control" placeholder="login" />
      <input type="password" className="form-control" placeholder="Password" />
      <button className="w-100 btn btn-lg btn-primary" type="submit">Submit</button>
    </form>
  );
}

export default RegisterForm;