import { Home } from "@components/Home";
import { Banner } from "@components/Banner";
import { Dashboard } from "@admin/Dashboard";
import { Registrations } from "@admin/Applicants";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import './App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Banner/>
        <Switch>
          <Route path="/admin/registrations"><Registrations/></Route>
          <Route path="/admin"><Dashboard/></Route>
          <Route path="/"><Home /></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
