import LoginActionTypes from "./enums"
import { LoginAction, LoginState } from "./interfaces"

const initialState: LoginState = {
  wasLogin: false,
  loading: false,
  error: null
}

export const LoginReducer = (state = initialState, action: LoginAction): LoginState => {
  switch(action.type){
    case LoginActionTypes.FETCH_LOGIN:
      return { loading: true, error: null, wasLogin: false }

    case LoginActionTypes.FETCH_LOGIN_SUCCESS:
      return { loading: false, error: null, wasLogin: action.payload }

    case LoginActionTypes.FETCH_LOGIN_ERROR:
      return { loading: false, error: action.payload, wasLogin: action.payload }

      default:
        return state;
  }
}