import { ExpansionPanelActions } from "@material-ui/core";
import { IsoTwoTone } from "@material-ui/icons";
import { render, screen } from "@testing-library/react";
import { Login } from "./index";

describe("<Login />", () => {

  it("should load the component", () => {
    render(<Login />);
    expect(screen.getByTestId("login-page")).toBeInTheDocument();
  })
})