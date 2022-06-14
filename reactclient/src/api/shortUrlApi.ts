import axios from "axios";
import { Dispatch } from "redux";
import ShortUrlActionTypes from "../redux/reducers/shortenerUrl/enums";
import { ShortUrlAction } from "../redux/reducers/shortenerUrl/interfaces";

export const fetchShortUrl = (url: any): any => {
  return async (dispatch: Dispatch<ShortUrlAction>) => {
    try{
      dispatch({type: ShortUrlActionTypes.FETCH_SHORT_URL});

      const response = await axios.get(`https://api.shrtco.de/v2/shorten?url=${url}`);

      const responseSaveUrl = await fetch(`http://localhost:8000/api/Url/save-url`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        credentials: 'include',
        body: JSON.stringify({
          fullUrl: url,
          shortUrl: response.data.result.full_short_link
        })
      })
      
      dispatch({
        type: ShortUrlActionTypes.FETCH_SHORT_URL_SUCCESS,
        payload: response.data.result.full_short_link
      });
    } catch (e) {
      dispatch({
        type: ShortUrlActionTypes.FETCH_SHORT_URL_ERROR,
        payload: "Error logout"
      });
    }
  }
}