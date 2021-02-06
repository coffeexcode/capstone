import { screen, fireEvent } from '@testing-library/react';
import { renderWithRouter } from "../../../../utils/test";
import App from '../../../../App';

test('sidebar statistics link goes to correct path', () => {
  renderWithRouter(<App />, { route: "/admin"});
  const linkElement = screen.getByTestId("statistics");
  fireEvent.click(linkElement, { button: 0 });
  expect(screen.getByTestId(/statistics-page/i)).toBeInTheDocument();
});

test('sidebar registrations link goes to correct path', () => {
  renderWithRouter(<App />, { route: "/admin"});
  const linkElement = screen.getByTestId("registrations");
  fireEvent.click(linkElement, { button: 0 });
  expect(screen.getByTestId(/registrations-page/i)).toBeInTheDocument();
});
