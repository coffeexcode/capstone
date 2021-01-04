import { Home } from "@components/Home";
import { Banner } from "@components/Banner";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import './App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Banner/>
        <Switch>
          <Route path="/"><Home /></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
