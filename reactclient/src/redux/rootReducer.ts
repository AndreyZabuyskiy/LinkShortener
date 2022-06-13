import { combineReducers } from "redux";
import { authReducer } from "./reducers/auth/authReducer";
import { loginReducer } from "./reducers/login/loginReducer";
import { registerReducer } from "./reducers/register/registerReducer";

export const rootReducer = combineReducers({
  registerReducer, loginReducer, authReducer
});

export type RootState = ReturnType<typeof rootReducer>