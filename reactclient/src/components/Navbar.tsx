import { SyntheticEvent } from "react";
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { fetchLogout } from "../api/loginApi";
import { useTypedSelector } from "../hooks/useTypedSelector";

const Navbar = () => {
  const { user } = useTypedSelector(state => state.authReducer);
  const dispatch = useDispatch();

  const logout = (e: SyntheticEvent) => {
    dispatch(fetchLogout());
  }

  let menuElement;
  
  if(user == null) {
    menuElement = (
      <div>
        <ul className="navbar-nav me-auto mb-2 mb-md-0">
          <li className="nav-item">
            <Link className="nav-link active" to="/login">Login</Link>
          </li>
          <li className="nav-item">
            <Link className="nav-link active" to="/register">Register</Link>
          </li>
        </ul>
      </div>
    )
  }
  else {
    menuElement = (
      <div>
        <ul className="navbar-nav me-auto mb-2 mb-md-0">
          <li className="nav-item">
            <Link className="nav-link active" to="/login" onClick={logout}>Logout</Link>
          </li>
        </ul>
      </div>
    )
  }
  
  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
        <Link className="navbar-brand" to="/home">Home</Link>
        { menuElement }
      </div>
    </nav>
  );
}

export default Navbar;