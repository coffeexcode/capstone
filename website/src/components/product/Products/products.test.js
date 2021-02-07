import { render, screen, fireEvent } from "@testing-library/react";
import { Details } from "./Details";
import { Products } from "./index";

describe("<Products/>", () => {
  describe("<Details />", () => {
    const heading = "Test Heading";
    const subheading = "Test Subheading";
    const product_description = "This is a test product";

    const details = (
      <Details
        heading={heading}
        subheading={subheading}
        product_description={product_description}
      />
    );

    it("renders product heading correctly", () => {
      render(details);
      expect(screen.getByText(heading)).toBeInTheDocument();
    });
    
    it("renders product subheading correctly", () => {
      render(details);
      expect(screen.getByText(subheading)).toBeInTheDocument();
    })

    it("renders product description correctly", () => {
      render(details);
      expect(screen.getByText(subheading)).toBeInTheDocument();
    })
  });

  it("should contain details about basic plan", () => {
    render(<Products />);
    expect(screen.getByText("Basic Event")).toBeInTheDocument();
  });

  it("should contain details about advanced plan", () => {
    render(<Products />);
    expect(screen.getByText("Advanced Event")).toBeInTheDocument();
  });

  it("should contain details about commercial plan", () => {
    render(<Products />);
    expect(screen.getByText("Commercial Event")).toBeInTheDocument();
  })
});
