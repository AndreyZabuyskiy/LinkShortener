import { combineReducers } from "redux";
import { authReducer } from "./reducers/auth/authReducer";
import { historyReducer } from "./reducers/history/historyReducer";
import { loginReducer } from "./reducers/login/loginReducer";
import { registerReducer } from "./reducers/register/registerReducer";
import { shortUrlReducer } from "./reducers/shortenerUrl/shortUrlReducer";

export const rootReducer = combineReducers({
  registerReducer, loginReducer, authReducer, shortUrlReducer, historyReducer
});

export type RootState = ReturnType<typeof rootReducer>