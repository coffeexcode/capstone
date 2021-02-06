import { render, screen, fireEvent } from '@testing-library/react';
import { Dashboard } from "./index";
import jest from "jest";

test("dashboard widgets all render", () => {
  render(<Dashboard/>);

  expect(screen.getByText(/Pending Applications/i)).toBeInTheDocument();
  expect(screen.getByText(/Event Views/i)).toBeInTheDocument();
  expect(screen.getByText(/Accepted Applications/i)).toBeInTheDocument();
  expect(screen.getByText(/Application Overview/i)).toBeInTheDocument();
})