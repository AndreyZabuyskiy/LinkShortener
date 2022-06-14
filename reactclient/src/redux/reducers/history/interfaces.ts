import HistoryActionTypes from "./enums";

export interface HistoryState {
  links: any[] | null;
  loading: boolean;
  error: null | string
}

interface FetchHistoryAction{
  type: HistoryActionTypes.FETCH_HISTORY
}

interface FetchHistorySuccessAction{
  type: HistoryActionTypes.FETCH_HISTORY_SUCCESS;
  payload: any;
}

interface FetchHistoryErrorAction{
  type: HistoryActionTypes.FETCH_HISTORY_ERROR;
  payload: any;
}

export type HistoryAction = FetchHistoryAction
  | FetchHistorySuccessAction
  | FetchHistoryErrorAction