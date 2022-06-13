import { useTypedSelector } from "../hooks/useTypedSelector";

const Home = () => {
  const { user } = useTypedSelector(state => state.authReducer);

  if(user == null){
    return (
      <div>Не авторизован</div>
    )
  }
  
  return (
    <div> Home {user.login} </div>
  );
}

export default Home;