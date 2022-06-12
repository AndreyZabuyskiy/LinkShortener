import React from "react";

const LoginForm = () => {
  return (
    <form>
      <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
      <input type="text" className="form-control" placeholder="login" />
      <input type="password" className="form-control" placeholder="Password" />
      <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>
    </form>
  );
}

export default LoginForm;