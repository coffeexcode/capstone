import { render, screen, fireEvent } from '@testing-library/react';
import { Dashboard } from "./index";

global.fetch = jest.fn(() => Promise.resolve({}));

describe("<Dashboard/>", () => {
  
  it('renders pending applications widget', () => {
    render(<Dashboard/>);
    expect(screen.getByText(/Pending Applications/i)).toBeInTheDocument();
  });

  it('renders event views widget', () => {
    render(<Dashboard/>);
    expect(screen.getByText(/Event Views/i)).toBeInTheDocument();
  });

  it('renders accepted applications widget', () => {
    render(<Dashboard/>);
    expect(screen.getByText(/Accepted Applications/i)).toBeInTheDocument();
  });

  it('renders application overview chart', () => {
    render(<Dashboard/>);
    expect(screen.getByText(/Application Overview/i)).toBeInTheDocument();
  });

  it('should fetch applicant data from faker file or API', () => {
    render(<Dashboard/>);

    expect(fetch).toHaveBeenCalled();
  })
})