import { render, screen, fireEvent } from '@testing-library/react';
import { renderWithRouter } from "../../utils/test";
import App from '../../App';


describe( '<Banner/>', () => {
  it('goes to the correct component on clicking the about link', () => {
    renderWithRouter(<App />);
    const linkElement = screen.getByTestId("about");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId(/about-page/i)).toBeInTheDocument();
  });
  
  it('goes to the correct component on clicking the products link', () => {
    renderWithRouter(<App />);
    const linkElement = screen.getByTestId("products");
    fireEvent.click(linkElement, { button: 0 });
    expect(screen.getByTestId(/product-page/i)).toBeInTheDocument();
  });
  
  
  // it('downloads link goes to correct path*', () => {
  //   renderWithRouter(<App />);
  //   const linkElement = screen.getByTestId("downloads");
  //   fireEvent.click(linkElement, { button: 0 });
  //   expect(screen.getByTestId(/downloads-page/i)).toBeInTheDocument();
  // })
  
  // it('account link goes to correct path*', () => {
  //   renderWithRouter(<App />);
  //   const linkElement = screen.getByTestId("account");
  //   fireEvent.click(linkElement, { button: 0 });
  //   expect(screen.getByTestId(/account-page/i)).toBeInTheDocument();
  // })
})
