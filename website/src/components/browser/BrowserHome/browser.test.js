import { render, screen, fireEvent } from '@testing-library/react';
import { BrowserHome } from "./index";
import { Backdrop } from "@material-ui/core";
import { Sidebar } from "@browser/FilterSidebar";
import { mount } from 'enzyme';
import { ConferenceWidget } from "@browser/ConferenceWidget";


global.fetch = jest.fn(() => Promise.resolve({}));

describe("<BrowserHome/>", () => {
  
  it('Renders all filters in FilterSidebar', () => {
    render(<BrowserHome/>);
    const testData = [
        {filter: "All"},
        {filter: "For You"},
        {filter: "Today"},
        {filter: "This weekend"},
        {filter: "Free"},
        {filter: "Education"},
        {filter: "Food and Drink"},
        {filter: "Charity and Causes"},
      ];
      testData.forEach(({filter}) => {
        expect(screen.getByText(filter)).toBeInTheDocument();
      })
  });

  it('Should open conference widget.', () => {
    render(<BrowserHome/>);

    const element = screen.getAllByTestId("opencard")[0];
    fireEvent.click(element, { button: 0 });

    expect(screen.getByTestId("media")).toBeInTheDocument();
    expect(screen.getByTestId("date")).toBeInTheDocument();
    expect(screen.getByTestId("title")).toBeInTheDocument();
  })

  it('Modal should close', () => {
    const wrapper = mount(<BrowserHome />);
    const button = wrapper.find({'data-testid': "opencard"}).at(1);
    button.simulate('click');
    wrapper.find(Backdrop).simulate('click');

    // check the modal is closed.
    expect(screen.getByTestId('modal').at(0).props().open).toBe(false);
  })

  it('Register should toggle', () => {
    render(<BrowserHome/>);
    const element = screen.getAllByTestId("opencard")[0];
    fireEvent.click(element, { button: 0 });
    const linkElement = screen.getByTestId("registerbutton");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByText("Register")).toBeInTheDocument();
  })
  it('sponsor should toggle', () => {
    render(<BrowserHome/>);
    const element = screen.getAllByTestId("opencard")[0];
    fireEvent.click(element, { button: 0 });
    const linkElement = screen.getByTestId("registerbutton");
    fireEvent.click(linkElement, { button: 0 });
    const linkElement2 = screen.getByTestId("sponsorbutton");
    fireEvent.click(linkElement2, { button: 0 });
    expect(screen.getByText("Unsponsor")).toBeInTheDocument();
  })

  it('reminder should toggle', () => {
    render(<BrowserHome/>);
    const element = screen.getAllByTestId("opencard")[0];
    fireEvent.click(element, { button: 0 });
    const linkElement = screen.getByTestId("registerbutton");
    fireEvent.click(linkElement, { button: 0 });
    const linkElement2 = screen.getByTestId("remindbutton");
    fireEvent.click(linkElement2, { button: 0 });
    expect(screen.getByText("Don't Remind Me")).toBeInTheDocument();
  })


  it('should fetch conference data from faker file or API', () => {
    render(<BrowserHome/>);

    expect(fetch).toHaveBeenCalled();
  })
})