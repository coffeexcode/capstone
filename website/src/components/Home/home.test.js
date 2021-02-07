import { render, screen, fireEvent } from '@testing-library/react';
import { renderWithRouter } from "../../utils/test";
import App from '../../App';


describe( '<Home />', () => {
  it('goes to the correct component on clicking get started link', () => {
    renderWithRouter(<App />);
    const linkElement = screen.getByTestId("get-started-link");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId("get-started")).toBeInTheDocument();
  });
  
  it('goes to the correct component on clicking the browse events link', () => {
    renderWithRouter(<App />);
    const linkElement = screen.getByTestId("browser-home-link");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId("browser-home")).toBeInTheDocument();
  });
})
