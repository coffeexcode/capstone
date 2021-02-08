import React from 'react';
import { render } from '@testing-library/react-native';

import CAText from '@core/CAText';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<CAText/>', () => {
  it('renders the Text properly', () => {
    const tree = render(<CAText/>).toJSON();
    expect(tree.type).toBe('Text');
  })

  it('passes the proper text into the Text component', () => {
    const testProps = {
      text: 'test'
    }
    const comp = render(<CAText testID='test'>{testProps.text}</CAText>);
    const text = comp.getByTestId('test');
    expect(text.children[0]).toBe(testProps.text);
  })
  
  it('renders the text with the proper specified size', () => {
    const testProps = {
      size: 'lg'
    }
    const expectedFontSize = { fontSize: 34 };

    const comp = render(<CAText testID='test' size={testProps.size}/>);
    const text = comp.getByTestId('test');
    expect(text.props.style[3]).toStrictEqual(expectedFontSize);
  })
})
