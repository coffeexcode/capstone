import { Home } from "@components/Home"
import { Route } from "react-router";

import './App.css';

function App() {
  return (
    <div className="App">
      <Route path="/"><Home /></Route>
    </div>
  );
}

export default App;
