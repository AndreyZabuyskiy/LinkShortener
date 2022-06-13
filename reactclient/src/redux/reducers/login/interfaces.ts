import LoginActionTypes from "./enums";

export interface LoginState {
  wasLogin: boolean;
  loading: boolean;
  error: string | null;
}

interface FetchLoginAction {
  type: LoginActionTypes.FETCH_LOGIN
}

interface FetchLoginSuccessAction {
  type: LoginActionTypes.FETCH_LOGIN_SUCCESS;
  payload: any;
}

interface FetchLoginErrorAction {
  type: LoginActionTypes.FETCH_LOGIN_ERROR;
  payload: any;
}

export type LoginAction = FetchLoginAction
  | FetchLoginSuccessAction
  | FetchLoginErrorAction