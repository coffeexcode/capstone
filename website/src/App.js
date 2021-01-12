import { Home } from "@components/Home";
import { Banner } from "@components/Banner";
import { Dashboard } from "@admin/Dashboard";
import { Applicants } from "@admin/Applicants";
import { BrowserHome } from "@browser/BrowserHome";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import './App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Banner/>
        <Switch>
          <Route path="/admin/applications"><Applicants/></Route>
          <Route path="/admin"><Dashboard/></Route>
          <Route path="/browser"><BrowserHome/></Route>
          <Route path="/"><Home /></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
