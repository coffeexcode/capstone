import React from 'react';
import { render, fireEvent } from '@testing-library/react-native';
import About from '@screens/Attendee/About';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

global.fetch = jest.fn(() => Promise.resolve({}));

describe('<About/>', () => {
  it('should render the View properly', () => {
    const tree = render(<About />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should navigate to the Sponsors screen when button is pressed', () => {
    const navigation = {
      navigate: jest.fn()
    }
    const comp = render(<About navigation={navigation} />);
    const button = comp.getByTestId('sponsorsBtn');

    fireEvent(button, 'press');

    expect(navigation.navigate).toHaveBeenCalledWith('Sponsors');
  })

  it('should fetch the expected response from the API', () => {
    const comp = render(<About />);
  })
})
