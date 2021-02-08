import { ExpansionPanelActions } from "@material-ui/core";
import { render, screen, fireEvent } from "@testing-library/react";
import { About } from "./index";
import team from '../../../../public/data/team.json';

global.fetch = jest.fn(() => Promise.resolve({}));

describe("<About/>", () => {
  it("should display developer name", () => {
    const developers = [{
      "name": "John Doe",
      "github": "https://github.com/enricoflorentino",
      "github_img": "https://avatars2.githubusercontent.com/u/33015189?v=4",
      "role": "Developer"
    }];
    render(<About developers={developers}/>);

    expect(screen.getByText("John Doe")).toBeInTheDocument();
  });

  // it("should display developer role", () => {
  //   const developers = [{
  //     "name": "John Doe",
  //     "github": "https://github.com/enricoflorentino",
  //     "github_img": "https://avatars2.githubusercontent.com/u/33015189?v=4",
  //     "role": "Developer"
  //   }];
  //   render(<About developers={developers}/>);

  //   expect(screen.getByText("Developer")).toBeInTheDocument();
  // });  
  
  // it("should display developer role", () => {
  //   const developers = [{
  //     "name": "John Doe",
  //     "github": "https://github.com/enricoflorentino",
  //     "github_img": "https://avatars2.githubusercontent.com/u/33015189?v=4",
  //     "role": "Developer"
  //   }];
  //   render(<About developers={developers}/>);

  //   expect(screen.getByText("Developer")).toBeInTheDocument();
  // });

  it("should fetch team members from webpack bundled json", () => {
    render(<About/>);

    expect(fetch).toHaveBeenCalled();
  });
})

