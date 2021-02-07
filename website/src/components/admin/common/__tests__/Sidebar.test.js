import { screen, fireEvent } from "@testing-library/react";
import { renderWithRouter } from "../../../../utils/test";
import App from "../../../../App";
import { IsoTwoTone } from "@material-ui/icons";

describe("<Sidebar />", () => {
  it("should render statistics component on clicking link", () => {
    renderWithRouter(<App />, { route: "/admin" });

    const linkElement = screen.getByTestId("statistics");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId(/statistics-page/i)).toBeInTheDocument();
  });

  it("should render registrations component on clicking link", () => {
    renderWithRouter(<App />, { route: "/admin" });

    const linkElement = screen.getByTestId("registrations");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId(/registrations-page/i)).toBeInTheDocument();
  });

  it("should render admin help component on clicking link", () => {
    renderWithRouter(<App />, { route: "/admin"});

    const linkElement = screen.getByTestId("help-admin");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId(/help-admin-page/i)).toBeInTheDocument();
  })
});
