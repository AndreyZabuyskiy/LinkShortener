import ShortUrlActionTypes from "./enums"
import { ShortUrlAction, ShortUrlState } from "./interfaces"

const initialState: ShortUrlState = {
  shortUrl: null,
  loading: false,
  error: null
}

export const shortUrlReducer = (state = initialState, action: ShortUrlAction): ShortUrlState => {
  switch(action.type){
    case ShortUrlActionTypes.FETCH_SHORT_URL:
      return { loading: true, error: null, shortUrl: null }

    case ShortUrlActionTypes.FETCH_SHORT_URL_SUCCESS:
      return { loading: false, error: null, shortUrl: action.payload }

    case ShortUrlActionTypes.FETCH_SHORT_URL_ERROR:
      return { loading: false, error: action.payload, shortUrl: null }

    default: return state;
  }
}