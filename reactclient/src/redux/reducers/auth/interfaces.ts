import AuthActionTypes from "./enums";

export interface AuthState {
  user: any;
  loading: boolean;
  error: null | string
}

interface FetchAuthAction{
  type: AuthActionTypes.FETCH_AUTH
}

interface FetchAuthSuccessAction{
  type: AuthActionTypes.FETCH_AUTH_SUCCESS;
  payload: any;
}

interface FetchAuthUnsuccessAction {
  type: AuthActionTypes.FETCH_AUTH_UNSUCCESS
}

interface FetchAuthErrorAction{
  type: AuthActionTypes.FETCH_AUTH_ERROR;
  payload: any;
}

export type AuthAction = FetchAuthAction
  | FetchAuthSuccessAction
  | FetchAuthUnsuccessAction
  | FetchAuthErrorAction