import { SyntheticEvent, useState } from "react";
import { useDispatch } from "react-redux";
import { fetchShortUrl } from "../api/shortUrlApi";
import { useTypedSelector } from "../hooks/useTypedSelector";

const Home = () => {
  const { user } = useTypedSelector(state => state.authReducer);
  const { shortUrl, loading, error } = useTypedSelector(state => state.shortUrlReducer);
  const dispatch = useDispatch();
  const [url, setUrl] = useState('');

  if(user == null){
    return (
      <div>Не авторизован</div>
    )
  }

  const submit = (e: SyntheticEvent) => {
    e.preventDefault();
    dispatch(fetchShortUrl(url));
  }
  
  return (
    <div>
      <form onSubmit={submit}>
        <input type="text" className="form-control" placeholder="login"
        value={url} onChange={(e) => setUrl(e.target.value)} />
        <button className="w-10 btn btn-lg btn-primary" type="submit">Sign in</button>
      </form>
      <br />
      <br />
      <div>short url = {shortUrl}</div>
    </div>
  );
}

export default Home;