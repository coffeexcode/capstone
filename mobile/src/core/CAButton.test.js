import React from 'react';
import { render, fireEvent } from '@testing-library/react-native';

import CAButton from '@core/CAButton';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<CAButton/>', () => {
  it('renders the View properly', () => {
    const tree = render(<CAButton/>).toJSON();
    expect(tree.type).toBe('View'); 
  })
  
  it('passes the proper text into the Text component', () => {
    const testProps = {
      text: 'test'
    }
    const comp = render(<CAButton title={testProps.text} />);
    const button = comp.getByTestId('buttonText');
    expect(button.children[0]).toBe(testProps.text);
  })

  it('calls the onPress callback function when pressed', () => {
    const onPressMock = jest.fn();
    const comp = render(<CAButton testID='test' onPress={onPressMock}/>);
    const button = comp.getByTestId('test')
    
    fireEvent(button, 'press');

    expect(onPressMock).toHaveBeenCalled();
  })
})
