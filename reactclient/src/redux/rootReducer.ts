import { combineReducers } from "redux";
import { registerReducer } from "./reducers/register/registerReducer";

export const rootReducer = combineReducers({
  registerReducer
});

export type RootState = ReturnType<typeof rootReducer>