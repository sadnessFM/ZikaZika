using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ZikaZika.Client.Services.ProductService;
using ZikaZika.Shared;

namespace ZikaZika.Client.Services.CartService;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly IToastService _toastService;
    private readonly IProductService _productService;

    public event Action OnChange;

    public CartService(
        ILocalStorageService localStorage,
        IToastService toastService,
        IProductService productService)
    {
        _localStorage = localStorage;
        _toastService = toastService;
        _productService = productService;
    }

    public async Task AddToCart(CartItem item)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();

        CartItem? sameItem = cart
            .Find(x => x.ProductId == item.ProductId && x.EditionId == item.EditionId);
        if (sameItem == null)
        {
            cart.Add(item);
        }
        else
        {
            sameItem.Quantity += item.Quantity;
        }

        await _localStorage.SetItemAsync("cart", cart);

        Product product = await _productService.GetProduct(item.ProductId);
        _toastService.ShowSuccess($"Added to cart: {product.Title}");

        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        return cart ?? new List<CartItem>();
    }

    public async Task DeleteItem(CartItem item)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }

        CartItem? cartItem = cart.Find(x => x.ProductId == item.ProductId && x.EditionId == item.EditionId);
        cart.Remove(cartItem);

        await _localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task EmptyCart()
    {
        await _localStorage.RemoveItemAsync("cart");
        OnChange.Invoke();
    }
}