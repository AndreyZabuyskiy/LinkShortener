import AuthActionTypes from "./enums"
import { AuthAction, AuthState } from "./interfaces"

const initialState: AuthState = {
  user: null,
  loading: false,
  error: null
}

export const authReducer = (state = initialState, action: AuthAction): AuthState => {
  switch (action.type) {
    case AuthActionTypes.FETCH_AUTH:
      return { loading: true, error: null, user: null }
      
    case AuthActionTypes.FETCH_AUTH_SUCCESS:
      return { loading: false, error: null, user: action.payload }

    case AuthActionTypes.FETCH_AUTH_UNSUCCESS:
      return { loading: false, error: null, user: null }
      
    case AuthActionTypes.FETCH_AUTH_ERROR:
      return { loading: false, error: action.payload, user: null }

    default:
      return state;
  }
}