import { ExpansionPanelActions } from "@material-ui/core";
import { render, screen, fireEvent } from "@testing-library/react";
import { About } from "./index";
import team from '../../../../public/data/team.json';

global.fetch = jest.fn(() => Promise.resolve({}));

describe("<About/>", () => {
  it("should fetch team members from webpack bundled json", () => {
    render(<About/>);

    expect(fetch).toHaveBeenCalled();
  });
})

