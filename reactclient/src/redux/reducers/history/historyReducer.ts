import HistoryActionTypes from "./enums"
import { HistoryAction, HistoryState } from "./interfaces"

const initialState: HistoryState = {
  links: null,
  loading: false,
  error: null
}

export const historyReducer = (state = initialState, action: HistoryAction): HistoryState => {
  switch (action.type) {
    case HistoryActionTypes.FETCH_HISTORY:
      return { loading: true, error: null, links: null }
      
    case HistoryActionTypes.FETCH_HISTORY_SUCCESS:
      return { loading: false, error: null, links: action.payload }

    case HistoryActionTypes.FETCH_HISTORY_ERROR:
      return { loading: false, error: null, links: null }

    case HistoryActionTypes.FETCH_DELETE_URL:
      return { loading: false, error: null, links: action.payload }
    
    default:
      return state;
  }
}