import { Dispatch } from "redux";
import RegisterActionTypes from "../redux/reducers/register/enums"
import { RegisterAction } from "../redux/reducers/register/interfaces";

export const fetchRegister = (user: any): any => {
  return async (dispatch: Dispatch<RegisterAction>) => {
    try{
      dispatch({ type: RegisterActionTypes.FETCH_REGISTER })
      const login = user.login;
      const password = user.password;

      const response = await fetch(`http://localhost:8000/api/Auth/register`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({ login, password })
      })

      const content = await response.json();
      dispatch({ 
        type: RegisterActionTypes.FETCH_REGISTER_SUCCESS, 
        payload: content.data
      });
    } catch (e) {
      dispatch({
        type: RegisterActionTypes.FETCH_REGISTER_ERROR,
        payload: "Error register"
      });
    }
  }
}