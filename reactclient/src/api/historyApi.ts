import { Dispatch } from "redux";
import HistoryActionTypes from "../redux/reducers/history/enums";
import { HistoryAction } from "../redux/reducers/history/interfaces";

export const fetchHistory = (): any => {
  return async (dispatch: Dispatch<HistoryAction>) => {
    try{
      dispatch({ type: HistoryActionTypes.FETCH_HISTORY })
      
      const response = await fetch(`http://localhost:8000/api/Url/history`, {
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })

      const content = await response.json();
      dispatch({ 
        type: HistoryActionTypes.FETCH_HISTORY_SUCCESS, 
        payload: content.data
      });
    } catch (e) {
      dispatch({
        type: HistoryActionTypes.FETCH_HISTORY_ERROR,
        payload: "Error load history"
      });
    }
  }
}