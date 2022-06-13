import { Dispatch } from "redux";
import LoginActionTypes from "../redux/reducers/login/enums";
import { LoginAction } from "../redux/reducers/login/interfaces";

export const fetchLogin = (user: any): any => {
  return async (dispatch: Dispatch<LoginAction>) => {
    try{
      dispatch({ type: LoginActionTypes.FETCH_LOGIN })
      const login = user.login;
      const password = user.password;

      const response = await fetch(`http://localhost:8000/api/Auth/login`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        credentials: 'include',
        body: JSON.stringify({ login, password })
      })

      const content = await response.json();

      dispatch({ 
        type: LoginActionTypes.FETCH_LOGIN_SUCCESS, 
        payload: true
      });
    } catch (e) {
      dispatch({
        type: LoginActionTypes.FETCH_LOGIN_ERROR,
        payload: "Error login"
      });
    }
  }
}

export const fetchLogout = (): any => {
  return async (dispatch: Dispatch<LoginAction>) => {
    try{
      const response = await fetch(`http://localhost:8000/api/Auth/logout`, {
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })
      const content = await response.json();
      
      dispatch({ type: LoginActionTypes.FETCH_LOGOUT });
    } catch (e) {
      dispatch({
        type: LoginActionTypes.FETCH_LOGIN_ERROR,
        payload: "Error logout"
      });
    }
  }
}