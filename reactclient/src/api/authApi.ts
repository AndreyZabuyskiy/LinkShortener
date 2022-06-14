import { Dispatch } from "redux";
import AuthActionTypes from "../redux/reducers/auth/enums";
import { AuthAction } from "../redux/reducers/auth/interfaces";

export const fetchAuth = (): any => {
  return async (dispatch: Dispatch<AuthAction>) => {
    try {
      dispatch({ type: AuthActionTypes.FETCH_AUTH })
      
      const response = await fetch(`http://localhost:8000/api/Auth/user`, {
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })

      const content = await response.json();
      if(content.status === 1){
        dispatch({ type: AuthActionTypes.FETCH_AUTH_UNSUCCESS });
        return;
      }

      dispatch({ 
        type: AuthActionTypes.FETCH_AUTH_SUCCESS, 
        payload: content.data
      });
    } catch (e) {
      dispatch({
        type: AuthActionTypes.FETCH_AUTH_ERROR,
        payload: "Error load user"
      });
    }
  }
}