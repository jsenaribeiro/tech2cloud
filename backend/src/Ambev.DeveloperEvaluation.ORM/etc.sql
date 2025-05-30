-- psql -U developer -d developer_evaluation

select * from "Users";

select "Id", "Title" from "Products";

INSERT INTO "Products" ("Title", "Price", "Description", "Category", "Image", "CreatedAt") VALUES 
('Smartphone Galaxy Z', 999.99, 'A foldable smartphone with an advanced camera.', 'Electronics', 'https://example.com/images/galaxyz.jpg', NOW()),
('Laptop UltraBook Pro', 1499.50, 'Lightweight and powerful notebook for professionals and students.', 'Computers', 'https://example.com/images/ultrabook.jpg', NOW()),
('Premium Bluetooth Headphones', 189.00, 'Immersive audio with noise cancellation and long-lasting battery.', 'Audio', 'https://example.com/images/headphone.jpg', NOW()),
('55" 4K OLED Smart TV', 1299.99, 'Spectacular image quality with vibrant colors and perfect blacks.', 'Electronics', 'https://example.com/images/tv4k.jpg', NOW()),
('Professional DSLR Camera', 879.90, 'Capture incredible moments with high resolution and various scene modes.', 'Photography', 'https://example.com/images/dslr.jpg', NOW()),
('Next-Gen Video Game Console', 549.99, 'Guaranteed entertainment with realistic graphics and exclusive games.', 'Gaming', 'https://example.com/images/console.jpg', NOW()),
('Smart Robot Vacuum', 329.75, 'Keep your home clean automatically with scheduling and mapping.', 'Home & Kitchen', 'https://example.com/images/robotvacuum.jpg', NOW()),
('Automatic Espresso Machine', 419.00, 'Prepare your favorite coffee with just one touch, grinding beans on the spot.', 'Appliances', 'https://example.com/images/coffeemaker.jpg', NOW()),
('29-inch Mountain Bike', 699.00, 'Perfect for trails and adventures, with a lightweight frame and effective suspension.', 'Sports', 'https://example.com/images/mountainbike.jpg', NOW()),
('Ultra Comfort Running Shoes', 129.90, 'Responsive cushioning and ergonomic design for maximum performance.', 'Footwear', 'https://example.com/images/runningshoes.jpg', NOW()),
('Waterproof Executive Backpack', 85.50, 'Padded compartments for laptop and tablet, ideal for daily use.', 'Accessories', 'https://example.com/images/backpack.jpg', NOW());
