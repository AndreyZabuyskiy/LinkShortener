import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { fetchDeleteUrl, fetchHistory } from "../api/historyApi";
import { useTypedSelector } from "../hooks/useTypedSelector";

const History = () => {
  const { user } = useTypedSelector(state => state.authReducer);
  const { links, loading, error } = useTypedSelector(state => state.historyReducer);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(fetchHistory());
  }, []);

  if(user == null) return <div>Не авторизован</div>

  if(loading) return <div>Loading...</div>
  
  return (
    <div className="container">
      <div className="col d-flex flex-column justify-content-center align-items-center">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope='col'>Full url</th>
              <th scope='col'>Short url</th>
              <th scope='col'>Delete</th>
            </tr>
          </thead>
          <tbody>
            {
              links?.map(link => (
                <tr>
                  <td scope="row"> { link.fullUrl } </td>
                  <td> { link.shortUrl } </td>
                  <td>
                    <button className="btn btn-secondary btn-lg mx-3 my-3"
                    onClick={(id: any) => dispatch(fetchDeleteUrl(link.id))}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))
            }
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default History;