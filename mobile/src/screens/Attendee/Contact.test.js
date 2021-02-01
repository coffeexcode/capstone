import React from 'react';
import { render } from '@testing-library/react-native';

import Contact from '@screens/Attendee/Contact';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<Contact/>', () => {
  const route = {
    params: {
      item: {
        name: 'testName',
        contactFirstName: 'testFName',
        contactLastName: 'testLName',
        contactEmail: 'testEmail',
        contactPhone: 'testPhone'
      }
    }
  }

  it('should render the View properly', () => {
    const tree = render(<Contact route={route} />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should render the proper sponsor first name', () => {
    const comp = render(<Contact route={route} />);
    const text = comp.getByTestId('sponsorFName');
    expect(text).toBeTruthy();
  })

  it('should render the proper sponsor last name', () => {
    const comp = render(<Contact route={route} />);
    const text = comp.getByTestId('sponsorLName');
    expect(text).toBeTruthy();
  })

  it('should render the proper sponsor email', () => {
    const comp = render(<Contact route={route} />);
    const text = comp.getByTestId('sponsorEmail');
    expect(text).toBeTruthy();
  })

  it('should render the proper sponsor name', () => {
    const comp = render(<Contact route={route} />);
    const text = comp.getByTestId('sponsorPhone');
    expect(text).toBeTruthy();
  })
})
