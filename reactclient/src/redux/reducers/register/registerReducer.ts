import RegisterActionTypes from "./enums"
import { RegisterAction, RegisterState } from "./interfaces"

const initialState: RegisterState = {
  user: null,
  loading: false,
  error: null
}

export const registerReducer = (state = initialState, action: RegisterAction): RegisterState => {
  switch (action.type) {
    case RegisterActionTypes.FETCH_REGISTER:
      return { loading: true, error: null, user: null }
      
    case RegisterActionTypes.FETCH_REGISTER_SUCCESS:
      return { loading: false, error: null, user: action.payload }
      
    case RegisterActionTypes.FETCH_REGISTER_ERROR:
      return { loading: false, error: action.payload, user: null }

    default:
      return state;
  }
}