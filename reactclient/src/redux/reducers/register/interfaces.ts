import RegisterActionTypes from "./enums";

export interface RegisterState {
  user: any;
  loading: boolean;
  error: null | string
}

interface FetchRegisterAction{
  type: RegisterActionTypes.FETCH_REGISTER
}

interface FetchRegisterSuccessAction{
  type: RegisterActionTypes.FETCH_REGISTER_SUCCESS;
  payload: any;
}

interface FetchRegisterErrorAction{
  type: RegisterActionTypes.FETCH_REGISTER_ERROR;
  payload: any;
}

export type RegisterAction = FetchRegisterAction
  | FetchRegisterSuccessAction
  | FetchRegisterErrorAction