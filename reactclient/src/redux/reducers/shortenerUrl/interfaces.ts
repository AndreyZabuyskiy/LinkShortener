import ShortUrlActionTypes from "./enums";

export interface ShortUrlState {
  shortUrl: string | null;
  loading: boolean;
  error: string | null;
}

interface FetchShortUrlAction {
  type: ShortUrlActionTypes.FETCH_SHORT_URL
}

interface FetchShortUrlSuccessAction {
  type: ShortUrlActionTypes.FETCH_SHORT_URL_SUCCESS;
  payload: any;
}

interface FetchShortUrlErrorAction {
  type: ShortUrlActionTypes.FETCH_SHORT_URL_ERROR;
  payload: any;
}

export type ShortUrlAction = FetchShortUrlAction
  | FetchShortUrlSuccessAction
  | FetchShortUrlErrorAction