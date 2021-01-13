import { Home } from "@components/Home";
import { Banner } from "@components/Banner";
import { Dashboard } from "@admin/Dashboard";
import { Applicants } from "@admin/Applicants";
import { BrowserHome } from "@browser/BrowserHome";
import { Products } from "@product/Products"
import { About } from "@product/About";
import { Registrations } from "@admin/Applicants";
import { Statistics } from "@admin/Statistics";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import './App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Banner/>
        <Switch>
          <Route path="/products"><Products/></Route>
          <Route path="/about"><About/></Route>
          <Route path="/admin/registrations"><Registrations/></Route>
          <Route path="/admin/statistics"><Statistics/></Route>
          <Route path="/admin"><Dashboard/></Route>
          <Route path="/browser"><BrowserHome/></Route>
          <Route path="/"><Home /></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
